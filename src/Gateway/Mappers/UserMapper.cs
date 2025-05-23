﻿using Gateway.Contracts.Requests;
using Gateway.Database.Entities;
using ProtobufSpec.Events;

namespace Gateway.Mappers;

public static class UserMapper
{
    public static UserDto ToUserDto(this UserEntity userEntity)
    {
        return new UserDto
        {
            Id = userEntity.Id.ToString(),
            FirstName = userEntity.FirstName,
            LastName = userEntity.LastName,
            Email = userEntity.Email,
            EmailConfirmed = userEntity.EmailConfirmed
        };
    }

    public static ConfirmEmailEvent ToConfirmEmailEvent(this UserEntity userEntity)
    {
        return new ConfirmEmailEvent
        {
            UserId = userEntity.Id,
            Token = Guid.NewGuid()
        };
    }

    public static UserEntity ToUserEntity(this RegisterReq registerReq)
    {
        return new UserEntity
        {
            FirstName = registerReq.FirstName,
            LastName = registerReq.LastName,
            Email = registerReq.Email.ToLower(),
            Password = registerReq.Password
        };
    }
}