using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISARA.Application.Common.Base
{
    public class BaseError
    {
        public string? PropertyName { get; set; }
        public List<string>? Errors { get; set; }

    }
}
