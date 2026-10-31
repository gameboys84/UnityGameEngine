"""Run with py -3; validates comment filtering used by the source inventory."""
import importlib.util
from pathlib import Path
import re
import unittest

spec = importlib.util.spec_from_file_location('de_source_coverage', Path(__file__).with_name('de-source-coverage.py'))
module = importlib.util.module_from_spec(spec)
spec.loader.exec_module(module)


class CommentFilterTests(unittest.TestCase):
    def test_line_and_multiline_comments_are_excluded(self):
        source = '// { GlobalConstLocal.EMENU_DISABLED, "fake" },\n/* { GlobalConstLocal.EMENU_BLOCK, "fake" },\n*/\n{ GlobalConstLocal.EMENU_ACTIVE, "real" },'
        clean = module.strip_comments(source)
        self.assertNotIn('EMENU_DISABLED', clean)
        self.assertNotIn('EMENU_BLOCK', clean)
        self.assertIn('EMENU_ACTIVE', clean)
        self.assertEqual(source.count('\n'), clean.count('\n'))
        self.assertEqual(len(source), len(clean))

    def test_strings_verbatim_strings_and_char_literals_are_preserved(self):
        source = 'var url = "https://test/*path*/"; var text = @"a""//b"; var slash = \'/\'; // comment'
        clean = module.strip_comments(source)
        self.assertIn('"https://test/*path*/"', clean)
        self.assertIn('@"a""//b"', clean)
        self.assertIn("'/'", clean)
        self.assertNotIn('comment', clean)

    def test_escaped_quotes_do_not_end_a_string(self):
        source = r'var text = "a\"//b"; /* remove */ var next = 1;'
        clean = module.strip_comments(source)
        self.assertIn(r'"a\"//b"', clean)
        self.assertNotIn('remove', clean)
        self.assertIn('var next = 1;', clean)


if __name__ == '__main__':
    unittest.main()
