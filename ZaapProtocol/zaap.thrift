namespace netstd ZaapProtocol

struct ZaapError
{
  1: i32 code,
  2: string details
}

struct zaapMustUpdate_get_args
{
  1: string gameSession
}

struct zaapMustUpdate_get_result
{
  1: bool Success
}

struct zaapVersion_get_args
{
  1: string gameSession
}

struct zaapVersion_get_result
{
  1: string Success
}

struct settings_get_args
{
  1: string gameSession,
  2: string key
}

struct settings_get_result
{
  1: string success,
  2: ZaapError error
}

struct settings_set_args
{
  1: string gameSession,
  2: string key,
  3: string value
}

struct settings_set_result
{
  1: ZaapError error
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

struct userInfo_get_args
{
  1: string gameSession
}

struct userInfo_get_result
{
  1: string success,
  2: ZaapError error
}

struct updater_isUpdateAvailable_args
{
  1: string gameSession
}

struct updater_isUpdateAvailable_result
{
  1: string success,
  2: ZaapError error
}

struct auth_getGameToken_args
{
  1: string gameSession,
  2: i32 gameId
}

struct auth_getGameToken_result
{
  1: string success,
  2: ZaapError error
}

struct auth_getGameTokenWithWindowId_args
{
  1: string gameSession,
  2: i32 gameId,
  3: i32 windowId
}

struct auth_getGameTokenWithWindowId_result
{
  1: string success,
  2: ZaapError error
}

service ZaapService
{
  updater_isUpdateAvailable_result updater_isUpdateAvailable(1:  updater_isUpdateAvailable_args request)
  auth_getGameTokenWithWindowId_result auth_getGameTokenWithWindowId(1:  auth_getGameTokenWithWindowId_args request)
  auth_getGameToken_result auth_getGameToken(1: auth_getGameToken_args request)
  settings_get_result settings_get(1: settings_get_args request)
  settings_set_result settings_set(1: settings_set_args request)
  userInfo_get_result userInfo_get(1: userInfo_get_args request)
  connect_result connect(1: connect_args request)
}