using Application.Abstractions;
using Application.Domains.Enums;

namespace Application.Domains.Entities;

public class User : IUser
{
    public string Id { get; }
    public DeliveryType DeliveryMethod { get; }
    public string Address { get; }
}