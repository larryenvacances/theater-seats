using System;

namespace Boilerplate.Application.DTOs.Theater
{
    public class MovieInsertDto
    {
        public string Title { get; set; }

        public DateTime DisplayStart { get; set; }

        public DateTime DisplayEnd { get; set; }
    }
}