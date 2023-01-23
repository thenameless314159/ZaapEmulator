namespace netstd ZaapProtocol

struct ZaapError
{
  1: i32 code,
  2: string details
}

struct connect_args
{
  1: string gameName,
  2: string releaseName,
  3: i32 instanceId,
  4: string hash
}

struct connect_result
{
  1: string success,
  2: ZaapError error
}

service ZaapConnectionService
{
  connect_result connect(1: connect_args request)
}