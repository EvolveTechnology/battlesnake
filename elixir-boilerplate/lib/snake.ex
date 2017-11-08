require Logger

defmodule Snake do
  use Application

  def start(_type, _args) do
    import Supervisor.Spec

    children = [
      Plug.Adapters.Cowboy.child_spec(:http, Snake.Router, [], [port: 8000])
    ]
    opts = [strategy: :one_for_one, name: Snake.Supervisor]

    Logger.info "Starting Cowboy"
    Supervisor.start_link(children, opts)
  end
end
