﻿using System;
using System.Linq;
using AutoMapper;
using EventsExpress.Core.DTOs;
using EventsExpress.Core.Extensions;
using EventsExpress.Db.Entities;
using EventsExpress.ViewModels;
namespace EventsExpress.Mapping
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Categories, opts => opts.MapFrom(src => src.Categories))
                .ForMember(dest => dest.Events, opts => opts.Ignore())
                .ForMember(dest => dest.RefreshTokens, opts => opts.MapFrom(src => src.RefreshTokens));

            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.EmailConfirmed, opts => opts.MapFrom(src => src.EmailConfirmed))
                .ForMember(dest => dest.Birthday, opts => opts.MapFrom(src => src.Birthday))
                .ForMember(dest => dest.Gender, opts => opts.MapFrom(src => src.Gender))
                .ForMember(dest => dest.IsBlocked, opts => opts.MapFrom(src => src.IsBlocked))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.PasswordHash, opts => opts.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.PhotoId, opts => opts.MapFrom(src => src.PhotoId))
                .ForMember(dest => dest.RoleId, opts => opts.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.Categories, opts => opts.MapFrom(src => src.Categories))
                .ForMember(dest => dest.Phone, opts => opts.MapFrom(src => src.Phone))
                .ForMember(dest => dest.RefreshTokens, opts => opts.MapFrom(src => src.RefreshTokens))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<UserDTO, UserInfoViewModel>()
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name ?? src.Email.Substring(0, src.Email.IndexOf("@", StringComparison.Ordinal))))
                .ForMember(dest => dest.Role, opts => opts.MapFrom(src => src.Role.Name))
                .ForMember(
                    dest => dest.Categories,
                    opts => opts.MapFrom(src =>
                        src.Categories.Select(x => new CategoryViewModel { Id = x.Category.Id, Name = x.Category.Name })))
                .ForMember(
                    dest => dest.PhotoUrl,
                    opts => opts.MapFrom(src => src.Photo.Thumb.ToRenderablePictureString()))
                .ForMember(dest => dest.Gender, opts => opts.MapFrom(src => src.Gender));

            CreateMap<UserDTO, UserManageViewModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.Username, opts => opts.MapFrom(src => src.Name ?? src.Email.Substring(0, src.Email.IndexOf("@", StringComparison.Ordinal))))
                .ForMember(dest => dest.IsBlocked, opts => opts.MapFrom(src => src.IsBlocked))
                .ForMember(
                    dest => dest.Role,
                    opts => opts.MapFrom(src => new RoleViewModel { Id = src.RoleId, Name = src.Role.Name }))
                .ForMember(
                    dest => dest.PhotoUrl,
                    opts => opts.MapFrom(src => src.Photo.Thumb.ToRenderablePictureString()));

            CreateMap<UserDTO, UserPreviewViewModel>()
                .ForMember(
                    dest => dest.Username,
                    opts => opts.MapFrom(src => src.Name ?? src.Email.Substring(0, src.Email.IndexOf("@", StringComparison.Ordinal))))
                .ForMember(
                    dest => dest.PhotoUrl,
                    opts => opts.MapFrom(src => src.Photo.Thumb.ToRenderablePictureString()));

            CreateMap<UserDTO, ProfileDTO>()
                .ForMember(
                    dest => dest.UserPhoto,
                    opts => opts.MapFrom(src => src.Photo.Thumb.ToRenderablePictureString()))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name ?? src.Email.Substring(0, src.Email.IndexOf("@", StringComparison.Ordinal))))
                .ForMember(
                    dest => dest.Categories,
                    opts => opts.MapFrom(src =>
                        src.Categories.Select(x => new CategoryViewModel { Id = x.Category.Id, Name = x.Category.Name })));

            CreateMap<ProfileDTO, ProfileViewModel>().ReverseMap();

            CreateMap<LoginViewModel, UserDTO>();
            CreateMap<UserViewModel, UserDTO>();
        }
    }
}
