FROM trenpixster/elixir:1.4.0

RUN mkdir /app
WORKDIR /app

ADD mix.* ./
RUN MIX_ENV=prod mix local.rebar
RUN MIX_ENV=prod mix local.hex --force
RUN MIX_ENV=prod mix deps.get

ADD . .
RUN MIX_ENV=prod mix compile

EXPOSE 8000

CMD MIX_ENV=prod elixir -S mix run --no-compile --no-halt
