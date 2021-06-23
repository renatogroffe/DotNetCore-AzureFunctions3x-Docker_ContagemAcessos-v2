using System;
using System.Reflection;
using System.Runtime.Versioning;

namespace FunctionAppContagem.Models
{
    public class ResultadoContador
    {
        private const string _VERSAO_FUNCTIONAPP = "1.0";
        private const string _SAUDACAO = "Bem-vindos!!!";
        private static readonly string _LOCAL;
        private static readonly string _KERNEL;
        private static readonly string _TARGET_FRAMEWORK;

        static ResultadoContador()
        {
            _LOCAL = Environment.MachineName;
            _KERNEL = Environment.OSVersion.VersionString;
            _TARGET_FRAMEWORK = Assembly
                .GetEntryAssembly()?
                .GetCustomAttribute<TargetFrameworkAttribute>()?
                .FrameworkName;
        }

        public int ValorAtual { get; }
        public int Incremento { get => Contador.INCREMENTO; }
        public string VersaoFunctionApp { get => _VERSAO_FUNCTIONAPP; }
        public string Saudacao { get => _SAUDACAO; }
        public string Local { get => _LOCAL; }
        public string Kernel { get => _KERNEL; }
        public string TargetFramework { get => _TARGET_FRAMEWORK; }

        public ResultadoContador(int valorAtual)
        {
            ValorAtual = valorAtual;
        }
    }
}
