using System;
namespace RtzenAPIs.models
{
    public class ResponseObject<T>
    {
        public List<T> Objects { get; set; }
        public PagingInfo Paging { get; set; }
        public int ObjectsSize { get; set; }
    }

    public class PagingInfo
    {
        public bool Previous { get; set; }
        public bool Next { get; set; }
    }
}

