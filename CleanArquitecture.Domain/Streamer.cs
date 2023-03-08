﻿using CleanArquitecture.Domain.Common;

namespace CleanArquitecture.Domain
{
    public class Streamer : BaseDomainModel
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public ICollection<Video>? Videos { get; set; }
    }
}
