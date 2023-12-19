using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UMBIT.Prototico.Core.Exececoes;

namespace UMBIT.Prototico.Core.API.Controller
{
    public abstract class UMBITControllerBase : ControllerBase
    {
        protected ActionResult MiddlewareDeRetorno(Func<ActionResult> retorno)
        {
            try
            {
                return retorno();

            }
            catch (UMBITExeception ex)
            {
                return BadRequest(ex.Mensagem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected async Task<ActionResult<T>> MiddlewareDeRetornoAsync<T>(Func<Task<ActionResult<T>>> retorno) where T : class 
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
        protected async Task<ActionResult> MiddlewareDeRetornoAsync(Func<Task<ActionResult>> retorno)
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
