defmodule Snake.Mixfile do
  use Mix.Project

  def project do
    [
      app: :snake,
      version: "0.1.0",
      elixir: "~> 1.4",
      build_embedded: Mix.env == :prod,
      start_permanent: Mix.env == :prod,
      deps: deps(),

      # Docs
      name: "BattleSnake Elixir",
      source_url: "https://github.com/leinonen/battlesnake-elixir",
      homepage_url: "http://leinonen.se"
    ]
  end

  # Configuration for the OTP application
  #
  # Type "mix help compile.app" for more information
  def application do
    [
      extra_applications: [:logger, :cowboy],
      mod: {Snake, []}
    ]
  end

  # Dependencies can be Hex packages:
  #
  #   {:my_dep, "~> 0.3.0"}
  #
  # Or git/path repositories:
  #
  #   {:my_dep, git: "https://github.com/elixir-lang/my_dep.git", tag: "0.1.0"}
  #
  # Type "mix help deps" for more examples and options
  defp deps do
    [
      {:plug, ">= 0.8.0"},
      {:cowboy, ">= 1.0.0"},
      {:poison, ">= 1.3.0"},
      {:ex_doc, "~> 0.16", only: :dev, runtime: false}
    ]
  end
end
