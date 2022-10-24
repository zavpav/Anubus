using Microsoft.EntityFrameworkCore.Diagnostics;
using Npgsql;
using System.Data.Common;

namespace Anubus.Db;

/// <summary> Интерцептор логирования "долгих" запросов в serilog </summary>
public class DbLogInterceptor : DbCommandInterceptor
{
    private readonly ILogger _logger;

    public DbLogInterceptor(ILogger logger)
    {
        this._logger = logger;
    }

    private const int LongExecuteTimeMillesecond = 500;

    public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
    {
        Console.WriteLine("DbLogInterceptor ReaderExecuted");

        if (eventData.Duration.TotalMilliseconds > LongExecuteTimeMillesecond)
        {
            this._logger
                .ForContext("Param", command.Parameters.OfType<NpgsqlParameter>().Select(x => new { x.ParameterName, x.Value }).ToList(), true)
                .Warning("Long sql reading [Time: {Time}] {Command}", eventData.Duration, command.CommandText);
        }

        return base.ReaderExecuted(command, eventData, result);
    }

    public override ValueTask<DbDataReader> ReaderExecutedAsync(DbCommand command, CommandExecutedEventData eventData, DbDataReader result, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("DbLogInterceptor ReaderExecutedAsync");
        if (eventData.Duration.TotalMilliseconds > LongExecuteTimeMillesecond)
        {
            var l = this._logger;

            foreach (NpgsqlParameter parameter in command.Parameters)
                l = l.ForContext("p_" + parameter.ParameterName, parameter.Value);

            l.Warning("Long sql reading [Time: {Time}] {Command}", eventData.Duration, command.CommandText);
        }

        return base.ReaderExecutedAsync(command, eventData, result, cancellationToken);
    }

    public override int NonQueryExecuted(DbCommand command, CommandExecutedEventData eventData, int result)
    {
        if (eventData.Duration.TotalMilliseconds > LongExecuteTimeMillesecond)
            this._logger.Warning("Long sql execute [Time: {Time}] {Command}", eventData.Duration, command.CommandText);

        return base.NonQueryExecuted(command, eventData, result);
    }

    public override ValueTask<int> NonQueryExecutedAsync(DbCommand command, CommandExecutedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        if (eventData.Duration.TotalMilliseconds > LongExecuteTimeMillesecond)
            this._logger.Warning("Long sql execute [Time: {Time}] {Command}", eventData.Duration, command.CommandText);

        return base.NonQueryExecutedAsync(command, eventData, result, cancellationToken);
    }
}
