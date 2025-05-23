﻿using ProtoBuf;

namespace ProtobufSpec.Events;

[ProtoContract]
public class ConfirmEmailEvent
{
    [ProtoMember(1)]
    public required Guid UserId { get; set; }
    
    [ProtoMember(2)]
    public required Guid Token { get; set; }
}