using System.Collections.Concurrent;

namespace ChatAplikace.Backend.Manager;

public class ConnectionManager
{
    private readonly ConcurrentDictionary<string, Guid> _connections = new();

    public void Add(string connectionId, Guid userId)
        => _connections[connectionId] = userId;

    public bool TryGetUser(string connectionId, out Guid userId)
        => _connections.TryGetValue(connectionId, out userId);

    public bool TryGetConnection(Guid userId, out string connectionId) {
        foreach (var pair in _connections)
        {
            if (pair.Value == userId)
            {
                connectionId = pair.Key;
                return true;
            }
        }

        connectionId = null;
        return false;
    }
    
    public void Remove(string connectionId)
        => _connections.TryRemove(connectionId, out _);
}