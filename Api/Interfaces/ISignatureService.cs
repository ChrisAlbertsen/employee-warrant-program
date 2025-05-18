using System.Threading.Tasks;
using BlazorApp.Shared;

namespace Api.Interfaces;

public interface ISignatureService
{
    public Task RequestSignatureAsync(Employee employee);
}