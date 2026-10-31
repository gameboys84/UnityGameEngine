using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("")]
public class TextCustom : Text
{
    public bool RuntimeControlled { get; set; }
    [SerializeField]
    private string stringLocKey = string.Empty;
    [SerializeField]
    private bool toUpper = false;
    [SerializeField]
    private bool isEllipsis = false;
    [SerializeField]
    private bool noneBreakingSpaceForCJK = false;
    protected override void Start()
    {
        base.Start();
        if (!RuntimeControlled && stringLocKey != string.Empty)
        {
            text = DE.Presentation.LegacyUI.LegacyLoadingContext.Localize(stringLocKey);
        }
    }
    public string GetLOCKey()
    {
        return stringLocKey;
    }
    public void SetLOCKey(string locKey)
    {
        stringLocKey = locKey;
    }
    public override string text {
        get
        {
            return base.text;
        }
        set 
        {
            base.text = (toUpper && value != null) ? value.ToUpper() : value;
            if (noneBreakingSpaceForCJK && DE.Presentation.LegacyUI.LegacyLoadingContext.IsCjk)
                base.text = base.text.Replace(" ", "\u00a0");

            if (isEllipsis && horizontalOverflow != HorizontalWrapMode.Overflow && verticalOverflow != VerticalWrapMode.Overflow)
            {
                base.text = TextWithEllipsis(base.text);
            }
        }
    }
    
    public string TextWithEllipsis(string value)
    {
        if (string.IsNullOrEmpty(value)) return value;
        if (value.Contains("<color=") || value.Contains("<size="))
        {
            return TruncateRichTextWithEllipsis(value);
        }
        var generator = new TextGenerator();
        var rectTransform = this.GetComponent<RectTransform>();
        var settings = this.GetGenerationSettings(rectTransform.rect.size);
        generator.Populate(value, settings);
        var characterCountVisible = generator.characterCountVisible;
        var updatedText = value;
        if (value.Length > characterCountVisible)
        {
            if (value.Length > characterCountVisible && characterCountVisible - 3 >= 0)
            {
                updatedText = value.Substring(0, characterCountVisible - 3);
                updatedText += "...";
            }
        }
        return updatedText;
    }

    
    // 去掉标签
    private string RemoveTags(string input)
    {
        return Regex.Replace(input, "<.*?>", "");
    }

    public string TruncateRichTextWithEllipsis(string richText)
    {
        // if (string.IsNullOrEmpty(richText))
        //     return richText;

        // 1. 获取纯文本
        string plainText = RemoveTags(richText);
        
        var generator = new TextGenerator();
        var rectTransform = this.GetComponent<RectTransform>();
        var settings = this.GetGenerationSettings(rectTransform.rect.size);
        generator.Populate(plainText, settings);
        var characterCountVisible = generator.characterCountVisible;

        if (plainText.Length <= characterCountVisible)
            return richText;

        int targetLength = characterCountVisible - 3; // 留给 "..."

        StringBuilder result = new StringBuilder();
        int plainIndex = 0;

        // 2. 遍历原字符串
        for (int i = 0; i < richText.Length; i++)
        {
            if (richText[i] == '<')
            {
                // 遇到标签，整段复制
                int end = richText.IndexOf('>', i);
                if (end == -1) break;

                result.Append(richText.Substring(i, end - i + 1));
                i = end;
            }
            else
            {
                if (plainIndex >= targetLength)
                    break;

                result.Append(richText[i]);
                plainIndex++;
            }
        }

        result.Append("...");

        // 3. 自动补全未闭合标签（关键）
        return CloseTags(result.ToString());
    }

    // 补全未闭合标签
    private string CloseTags(string input)
    {
        var stack = new Stack<string>();
        var matches = Regex.Matches(input, "<(/?)(\\w+)[^>]*>");

        foreach (Match m in matches)
        {
            bool isClose = m.Groups[1].Value == "/";
            string tag = m.Groups[2].Value;

            if (!isClose)
            {
                stack.Push(tag);
            }
            else if (stack.Count > 0 && stack.Peek() == tag)
            {
                stack.Pop();
            }
        }

        StringBuilder sb = new StringBuilder(input);

        while (stack.Count > 0)
        {
            sb.Append("</" + stack.Pop() + ">");
        }

        return sb.ToString();
    }
}
