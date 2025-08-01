using Code.DTOs.Response;

namespace Code.Interfaces
{
    public interface IPackageItemService
    {
        Task<PackageItemCodeResponseDto> GetPackageItemCodes();
    }
}