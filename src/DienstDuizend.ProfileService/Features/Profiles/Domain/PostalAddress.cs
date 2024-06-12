﻿namespace DienstDuizend.ProfileService.Features.Profiles.Domain;

public class PostalAddress{
    public Guid Id { get; set; }
    public string StreetAddress { get; set; }
    public string? StreetAddress2 { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
}