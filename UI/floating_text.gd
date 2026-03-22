extends Marker2D

# https://www.youtube.com/watch?v=uE4BIZ85Y9w

var velocity = Vector2(50, -100)
var gravity = Vector2(0, 1)
var mass = 200

var text: set = set_text, get = get_text
	
	
func _ready():
	
	"""
	Fade from current color after 0.7 seconds
	"""
	var tween = get_tree().create_tween()

	tween.tween_property(self, "modulate", Color(modulate.r, modulate.g, modulate.b, modulate.a), 3.0).set_trans(Tween.TRANS_LINEAR)
	tween.set_ease(Tween.EASE_OUT)
	
	"""
	Increase size
	After 0.6 seconds, start to shrink slightly
	"""
	
	
	
	"""
	After 1 second, call the destroy function to
	remove the floating text from the tree
	"""
	
	tween.tween_callback(self.queue_free)
	
	"""
	Start the tweens
	"""
	
	#tween.start()

func _process(delta):
	
	velocity += gravity * mass * delta
	
	position +=  velocity * delta


func set_text(new_text):
	
	$Label.text = str(new_text)


func get_text():
	
	return $Label.text


func destroy():
	#print("destroyed")
	queue_free()
