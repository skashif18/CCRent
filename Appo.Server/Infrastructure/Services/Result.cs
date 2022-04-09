namespace Appo.Server.Infrastructure.Services
{
    using System;
    public class Result
    {
        public bool Succeeded { get; private set; }
        public static implicit operator Result(bool succeeded)
            => new Result { Succeeded= succeeded};

        public string Error { get; private set; }

        public static implicit operator Result(string error)
           => new Result { 
               Succeeded = false,
               Error = error
           };

    }
}
