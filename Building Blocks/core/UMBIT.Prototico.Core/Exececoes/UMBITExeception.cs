using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMBIT.Prototico.Core.Exececoes
{
    public class UMBITExeception : Exception
    {
        public string Mensagem { get; private set; }
        public Exception ExcecaoInterna { get; private set; }
        public UMBITExeception(string mensagem) : base(mensagem)
        {
            this.Mensagem = mensagem;
        }
        public UMBITExeception(string mensagem, Exception ex) : base(mensagem, ex)
        {
            this.Mensagem = ex.GetType() == typeof(UMBITExeception) ? ((UMBITExeception)ex).Mensagem : mensagem;
            this.ExcecaoInterna = ex;

        }

        public override string ToString()
        {
            return this.Mensagem;
        }
    }
}
