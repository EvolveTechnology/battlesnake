const restify = require('restify')

const server = restify.createServer({
    name: 'Battle-Snake',
});

server.use(restify.plugins.bodyParser())

server.post('/start', function create(req, res, next) {

    const { game_id, width, height } = req.body
    
    console.log('Starting game...')
    
    res.json(200, {
        color: '#000000',
        secondary_color: '#ff0000',
        head_url: 'http://img.freepik.com/free-icon/snake-head_318-100146.jpg?size=338&ext=jpg',
        name: 'Snake',
        taunt: '',
        head_type: 'tongue',
        tail_type: 'freckled'
    })

    return next()
})

server.post('/move', function create(req, res, next) {

    const { you, food, snakes, width, height, dead_snakes } = req.body
    
    res.json(200, {
        move: 'up'        
    })

    return next()
})

console.log('listening on port 5000...')

server.listen(5000);