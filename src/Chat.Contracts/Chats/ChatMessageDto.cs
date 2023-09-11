﻿using Chat.Contracts.Users;
using MessagePack;

namespace Chat.Contracts.Chats;

[MessagePackObject]
public class ChatMessageDto
{
    [Key("id")]
    public Guid Id { get; set; }

    /// <summary>
    ///     内容
    /// </summary>
    [Key("content")]
    public string Content { get; set; }

    /// <summary>
    ///     类型
    /// </summary>
    [Key("type")]
    public ChatType Type { get; set; }

    /// <summary>
    ///     id
    /// </summary>
    [Key("userId")]
    public Guid UserId { get; set; }

    [IgnoreMember]
    public GetUserDto User { get; set; }

    /// <summary>
    /// 发送指定链接id
    /// </summary>
    [Key("groupId")]
    public Guid GroupId { get; set; }

    [Key("creationTime")]
    public DateTime CreationTime { get; set; }
}