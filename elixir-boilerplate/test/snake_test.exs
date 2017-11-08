defmodule SnakeTest do
  use ExUnit.Case, async: true
  use Plug.Test
  doctest Snake

  @opts Snake.Router.init([])

  test "handle start scenario" do
    conn = conn(:post, "/start")
    conn = Snake.Router.call(conn, @opts)

    assert conn.state == :sent
    assert conn.status == 200
    body = Poison.decode!(conn.resp_body)

    assert body["color"] == "#ffcc00"
    assert body["name"] == "Cowboy Snake"
    assert body["taunt"] == "I will crush you"
  end
end
