require Logger

defmodule Snake.Router do
  use Plug.Router
  import Plug.Conn

  plug :match
  plug :dispatch

  post "start" do
    Logger.info "start request"
    body = %{
      "color" => "#ffcc00",
      "name" => "Cowboy Snake",
      "taunt" => "I will crush you"
    }
    json(conn, body)
  end

  post "move" do
    Logger.info "move request"
    body = parse_json(conn)
    IO.inspect body
    body = %{
      "move" => "up",
      "taunt" => "Outta my way, snake!"
    }
    json(conn, body)
  end

  match _ do
    send_resp(conn, 404, "oops")
  end

  defp parse_json(conn) do
    {:ok, body, _} = read_body(conn, length: 1_000_000)
    Poison.decode!(body)
  end

  defp json(conn, content) do
    conn
    |> put_resp_header("content-type", "application/json")
    |> send_resp(200, render_json(content))
  end

  defp render_json(map) when is_map(map) do
    Poison.encode!(map, pretty: true)
  end
end