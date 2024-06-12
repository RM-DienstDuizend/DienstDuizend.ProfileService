namespace DienstDuizend.ProfileService.Common.Interfaces;

public interface ICurrentUserProvider
{
    public Guid GetCurrentUserId();
}