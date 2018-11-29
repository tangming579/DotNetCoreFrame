using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace ServiceCore
{
    public static class PublicDatas
    {
        public static IConfiguration Configuration { get; set; }
        public static IServiceProvider ServiceProvider { get; set; }

        public static JObject MainData { get; set; }

    }
}
