
using AutoMapper;
using Blogg.BL.DTOs.UserDTOs;
using Blogg.BL.Exceptions.Common;
using Blogg.BL.ExternalServices.JWTService;
using Blogg.BL.Helpers;
using Blogg.Core.Entities;
using Blogg.Core.Repositories;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace Blogg.BL.Services.UserService;

public class UserService(
    IUserRepository _repository,
    IMapper _mapper,
    IJWTTokenHandler _tokenHandler) : IUserService
{
    readonly HttpContext _context;
    public async Task<int> RegisterAsync(RegisterDTO dto)
    {
        await _repository.Register(_mapper.Map<User>(dto));
        User? user = await _repository.GetByUsernameOrEmailAsync(dto.Username);
        SendEmail(_tokenHandler.CreateToken(user, 1), user.Username);
        return user.Id;
    }
    public async Task<string> LoginAsync(LoginDTO dto)
    {
        User? user = await _repository.GetByUsernameOrEmailAsync(dto.UsernameOrEmail);
        if (user is null) throw new NotFoundException<User>();
        if (!HashHelper.VerifyHashedPassword(user.PasswordHash, dto.Password))
            throw new NotFoundException<User>();
        return _tokenHandler.CreateToken(user, 24);
    }
    public async Task DeleteAsync(int id)
    {
        User? user = await _repository.GetByIdAsync(id);
        if (user is null) throw new NotFoundException<User>();
        await _repository.DeleteAsync(user);
    }
    public IQueryable<User> GetAll()
    => _repository.GetAll();

    private void SendEmail(string token, string username)
    {
        using SmtpClient client = new SmtpClient();
        client.Host = "smtp.gmail.com";
        client.Port = 587;
        client.EnableSsl = true;
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential("sabuhies-ab108@code.edu.az", "lonk jxoz dbol want ");
        MailAddress from = new MailAddress("sabuhies-ab108@code.edu.az", "Blogg");
        MailAddress to = new MailAddress("sultanlisebuhi@gmail.com");
        MailMessage message = new MailMessage(from, to);
        message.Subject = "<p>Verify your email address</p>";
        string url = _context.Request.Scheme
            + "://" + _context.Request.Host
            + "/Account/VerifyEmail?token=" + token
            + "&user=" + username;
        message.IsBodyHtml = true;
        client.Send(message);
    }
}