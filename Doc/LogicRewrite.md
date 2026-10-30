# Core logic and business tests

This implementation rewrites the reference project's core network, server-time, operation progress and initial settlement flows. Shared mechanisms live in GameCore. Game-specific rules, numeric examples and simulated authority live in UnityProject1.

## Shared APIs

| API | Contract |
| --- | --- |
| IndexedTable | Positive unique identifiers; replacement is validated before commit |
| ServerClock | Server timestamp plus monotonic elapsed time; explicit synchronization and reset |
| BalanceLedger | Checked atomic balance changes, nonnegative balances, durable replay receipts and validated snapshots |
| OperationTimeline | Versioned full snapshots per group; defensive copies; expiry is not an authoritative completion |
| PacketWriter and PacketReader | Bounded big-endian integer, boolean, string and byte fields |
| NetworkPacket and PacketFramer | Two-byte body length; extended length after the sentinel; node and message identifiers; fragmented and combined input |
| PacketRouter | Disposable subscriptions and stable dispatch snapshots |
| TcpPacketSession | Serialized writes, bounded incoming queue, cancellation, close/reconnect isolation and callbacks dispatched by Pump |

Call Pump from the host's main-thread update loop. Configure connection timeouts through cancellation tokens. The default maximum body size is 8 MiB; the incoming queue is limited to 1024 packets and 16 MiB of bodies. The framing contract does not provide authentication, encryption, compression or a generated product protocol. Those belong to separate adapters. Raw TCP requires a platform that supports sockets.

The portable logic assembly does not use Unity, project globals, product configuration or service addresses.

## Business test model

SettlementSimulation contains the example authority for building upgrades, research, training and resource deductions. Rules are loaded from Assets/Resources/LogicTests/Rules.json. These numbers and prerequisite choices are test fixtures rather than production balance data.

Each operation kind has one slot. Successful starts debit all costs atomically and reserve a request receipt. Replays cannot debit again, including after a save/restore. Missing prerequisites, invalid quantities and insufficient resources leave the queue unchanged. Training produces units only after confirmation. Cancellation refunds half of the paid costs once; expired work must be confirmed. Acceleration charges only for time actually removed.

The clock drives remaining time. ConfirmElapsed represents an authority notification and applies the result. An elapsed client countdown alone does not award a building level, research level or units. Snapshot restore validates rule identities, levels, costs, receipts and queue ownership before replacing live state.

## Manual entry

Open the Launcher scene and enter Main. The LOGIC TESTS button opens the runtime dashboard. Build Headquarters, then Laboratory or Barracks; advance time and confirm elapsed work. Research requires the specified building and technology levels. The dashboard also exercises training, acceleration, cancellation, saving and loading.

The dashboard uses a local simulated authority and a separate logic-test save file. Network tests use loopback sockets. No legacy account, external service or platform integration is required.

## Integration scope

This covers the first dependency chain from shared mechanisms to settlement tests. Product login, generated protocol schemas, production tables, world maps, marching, combat, guilds, activities, payments and platform integrations remain separate work. The source project is read-only. Source evidence and temporary results are kept in ignored Design reports.

The development manifest references the local UPM working tree. Commit publication, the Ni submodule pointer and stable Git package pins have not been advanced by this work.

The local package HEAD is `5009668c98e1013b47bc90385497adc78c3d36ff`, with the Logic sources and package README still uncommitted. Checking out this consumer repository alone does not reproduce that dependency. The consumer commit does not publish the packages or authorize synchronization to Ni.
