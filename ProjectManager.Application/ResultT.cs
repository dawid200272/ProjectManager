using System.Text.Json.Serialization;

namespace ProjectManager.Application;
public sealed class ResultT<TValue> : Result
{
	private readonly TValue? _value;

	private ResultT(
		TValue value
	) : base()
	{
		_value = value;
	}

	private ResultT(
		Error error
	) : base(error)
	{
		_value = default;
	}

	public TValue Value =>
		IsSuccess ? _value! : throw new InvalidOperationException("Value can not be accessed when IsSuccess is false");

	public static implicit operator ResultT<TValue>(Error error) =>
		new(error);

	public static implicit operator ResultT<TValue>(TValue value) =>
		new(value);

	public static ResultT<TValue> Success(TValue value) =>
		new(value);

	public static new ResultT<TValue> Failure(Error error) =>
		new(error);
}

public enum ErrorType
{
	Failure = 0,
	NotFound = 1,
}

public class Error
{
	private Error(
		string code,
		string description,
		ErrorType errorType
	)
	{
		Code = code;
		Description = description;
		ErrorType = errorType;
	}

	public string Code { get; }

	public string Description { get; }

	public ErrorType ErrorType { get; }

	public static Error Failure(string code, string description) =>
		new(code, description, ErrorType.Failure);

	public static Error NotFound(string code, string description) =>
		new(code, description, ErrorType.NotFound);
}

public class Result
{
	protected Result()
	{
		IsSuccess = true;
		Error = default;
	}

	protected Result(Error error)
	{
		IsSuccess = false;
		Error = error;
	}

	public bool IsSuccess { get; }

	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public Error? Error { get; }

	public static implicit operator Result(Error error) =>
		new(error);

	public static Result Success() =>
		new();

	public static Result Failure(Error error) =>
		new(error);
}