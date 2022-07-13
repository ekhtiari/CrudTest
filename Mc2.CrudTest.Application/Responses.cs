using System.ComponentModel;

namespace Mc2.CrudTest.Application;

public class CreateCommandResponse : BaseResponse
{
    public Guid Id { get; set; }
}

public class DefaultCommandResponse 
{
}

public class QuerySingleResult<T> : BaseResponse
{
    public T Item { get; set; }        
}
public class QueryListResult<T> : BaseResponse
{
    public int TotalCount { get; set; }

    public ICollection<T> Items { get; set; }
}

public class QueryListResult<TItem, TMetadata> : QueryListResult<TItem>
{
    public TMetadata Metadata { get; set; }
}


public class BaseListQuery
{
    [DefaultValue(1)]
    public int StartPage { get; set; } = 1;
    [DefaultValue(10)]
    public int PageSize { get; set; } = 10;
    public List<string> Includes { get; set; }
    public List<string> OrderByFields { get; set; }
    public List<bool> OrderByDescs { get; set; }
    public List<Guid> SpecificIdsForFetch { get; set; }
}


public static class QueryResult
{
    public static QuerySingleResult<TItem> Success<TItem>(TItem item) => new()
    {
        Item = item,
    };

    public static QueryListResult<TItem> Success<TItem>(ICollection<TItem> items, int totalCount) => new()
    {
        Items = items,
        TotalCount = totalCount
    };

    public static QueryListResult<TItem, TMetadata> Success<TItem, TMetadata>(ICollection<TItem> items, TMetadata metadata, int totalCount) => new()
    {
        Items = items,
        Metadata = metadata,
        TotalCount = totalCount
    };

    
}

public class BaseResponse
{
    public ResponseError Error { get; set; }

    public static T ErrorResult<T>(string message) where T : BaseResponse, new()
    {
        return new T
        {
            Error = new ResponseError
            {
                Message = message
            }
        };
    }
}

public class ResponseError
{
    public int Code { get; set; }
    public string Message { get; set; }
}
