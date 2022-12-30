﻿global using MovieManager.Infrastructure;
global using MovieManager.Application;
global using Microsoft.AspNetCore.Mvc;
global using MediatR;
global using MovieManager.Application.Directors.Queries.GetDirectorDetail;
global using MovieManager.Application.Directors.Queries.GetDirectors;
global using MovieManager.Application.Directors.Commands.CreateDirector;
global using MovieManager.Application.Directors.Commands.DeleteDirector;
global using Serilog;
global using Microsoft.IdentityModel.Tokens;
global using System.Security.Claims;
global using IdentityModel;
global using MovieManager.Application.Common.Interfaces;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using MovieManager.Api.Service;
global using Swashbuckle.AspNetCore.SwaggerGen;
global using Microsoft.OpenApi.Models;
global using Microsoft.AspNetCore.Authorization;
global using MovieManager.Api;
global using MovieManager.Infrastructure.Identity;
global using Duende.IdentityServer.Models;
global using Microsoft.EntityFrameworkCore;
global using Duende.IdentityServer.Test;
global using Microsoft.AspNetCore.Authentication;