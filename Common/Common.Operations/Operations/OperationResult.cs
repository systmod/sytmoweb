﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Common
{
    public class OperationResult : IOperationResult
    {
        public OperationResult()
        {
        }

        public OperationResult(Exception ex)
        {
            Message = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
            StatusCode = HttpStatusCode.InternalServerError;
#if DEBUG
            Error = ex.ToString();
#else
            Error = $"{ex.Message} {ex?.InnerException?.Message} {ex?.InnerException?.InnerException?.Message}";
#endif
        }
         
        public OperationResult(HttpStatusCode status, string message = default, string exception = null) : this()
        {
            StatusCode = status;
            Message = message ?? $"El servidor respondio con el codigo de estado: {(int)status} {status}";
            Error = exception;
        }

        public string Error { get; set; }

        public string Message { get; set; } = "OK";

        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

        public bool Success => StatusCode < HttpStatusCode.BadRequest;

        public override string ToString()
        {
            return $"{(Success ? "SUCCESS" : "ERROR") } | {(int)StatusCode} {StatusCode} : {Message} - {Error}";
        } 
    }


    public class OperationResult<T> : OperationResult, IOperationResult<T> 
    {
        public OperationResult() : base()
        {
        }

        public OperationResult(Exception ex, T result = default) : base(ex)
        {
            Result = result;
        }


        public OperationResult(HttpStatusCode status, string message = null, T result = default, string error = default) : base(status, message, error)
        {
            if (result == null)
            {
                // Si Es ok pero no tiene entidad entonces hay un conflicto.
                if (StatusCode == HttpStatusCode.OK) 
                {
                    StatusCode = HttpStatusCode.NotFound;
                    Message = message ?? "El registro solicitado no existe o ya ha sido eliminado!";
                }
            }
            else
            {
                Result = result;
            }
        }

        public T Result { get; internal set; }
    }





    public class OperationResultList<T> : OperationResult, IOperationResultList<T>
    {
        const int maxPageSize = 50;
        private int _pageSize = 10;
        private int _length = 0;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

        public int Length
        {
            get => _length;
            set => _length = (value < Result.Count()) ? Result.Count() : value;
        }

        public int TotalPages => Length > 0 ? (int)Math.Ceiling(Length / (double)PageSize) : 0;
        public bool HasPrevious => PageNumber > 1;
        public bool HasNext => PageNumber < TotalPages;

        public IEnumerable<T> Result { get; set; } = new List<T>();

        public OperationResultList() : base() { }

        public OperationResultList(Exception ex, IEnumerable<T> result = default) : base(ex)
        {
            Result = result;
        }
         
        public OperationResultList(HttpStatusCode status, string message = null, IEnumerable<T> result = default, int pageNumber = 1, int? pageSize = default, int? count = default) : base(status, message)
        {
            if (result != null)
            {
                Result = result;
            }

            Length = count ?? Result.Count();
            PageSize = pageSize ?? Length;
            PageNumber = pageNumber; 
        }

    }
}
