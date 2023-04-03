using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeCBot.Interfaces
{
    public interface IAeCAPIContext
    {
        Task<T> GetConsult<T>(string url);
        Task<T> PostConsult<T>(string url, T data);
    }
}
