using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UMBIT.Prototico.Core.Exececoes;

namespace UMBIT.Prototico.Core.API.Controller
{
    public abstract class UMBITControllerBase : ControllerBase
    {
        protected IActionResult MiddlewareDeRetorno<T>(Func<T> retorno) where T : IActionResult
        {
            try
            {
                return retorno();

            }
            catch(UMBITExeception ex)
            {
                return BadRequest(ex.Mensagem);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        protected async Task<IActionResult> MiddlewareDeRetornoAsync(Func<Task<IActionResult>> retorno) 
        {
            try
            {
                return await retorno();
            }
            catch (UMBITExeception ex)
            {
                var res = BadRequest(ex.Mensagem);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
