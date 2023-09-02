﻿using AutoMapper;
using Chat.Service.Application.Users.Commands;
using Chat.Service.Domain.Chats.Aggregates;
using Chat.Service.Domain.Chats.Repositories;
using Chat.Service.Domain.Users.Aggregates;
using Chat.Service.Domain.Users.Repositories;
using Masa.BuildingBlocks.Data.UoW;

namespace Chat.Service.Application.Users;

public class UserCommandHandler
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IChatGroupInUserRepository _chatGroupInUserRepository;
    private readonly IChatGroupRepository _chatGroupRepository;

    public UserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper,
        IChatGroupInUserRepository chatGroupInUserRepository, IChatGroupRepository chatGroupRepository)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _chatGroupInUserRepository = chatGroupInUserRepository;
        _chatGroupRepository = chatGroupRepository;
    }

    [EventHandler(1)]
    public async Task CreateUserAsync(CreateUserCommand command)
    {
        if (await _userRepository.GetCountAsync(x => x.Account == command.CreateUserDto.Account) > 0)
            throw new Exception("用户已存在");

        var user = new User(command.CreateUserDto.Account, command.CreateUserDto.Password, command.CreateUserDto.Avatar,
            command.CreateUserDto.Name)
        {
            GiteeId = command.CreateUserDto.GiteeId,
            GithubId = command.CreateUserDto.GithubId
        };

        await _userRepository.AddAsync(user);
        command.Result = _mapper.Map<UserDto>(user);
    }

    [EventHandler(2)]
    public async Task DefaultGroupUserAsync(CreateUserCommand command)
    {
        var defaultGroup = await _chatGroupRepository.GetListAsync(x => x.Default);

        // TODO: 默认加入的群组
        await _chatGroupInUserRepository.AddRangeAsync(defaultGroup.Select(x => new ChatGroupInUser()
        {
            UserId = command.Result.Id,
            ChatGroupId = x.Id
        }));

    }

    [EventHandler]
    public async Task AuthUpdateAsync(AuthUpdateCommand command)
    {
        var user = await _userRepository.FindAsync(x => x.Id == command.userId);
        if (user == null)
        {
            return;
        }

        user.Name = command.name;
        user.Avatar = command.avatar;

        await _userRepository.UpdateAsync(user);
        await _unitOfWork.SaveChangesAsync();
    }
}