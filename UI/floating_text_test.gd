extends Node2D


var floaty_text_scene = preload("res://UI/floating_text.tscn")


func CreateFloatingText():
	var floaty_text = floaty_text_scene.instantiate()
	
	floaty_text.position = Vector2(480/2, 270/2)
	floaty_text.velocity = Vector2(randf_range(-50, 50), -100)
	floaty_text.modulate = Color(randf_range(0.7, 1), randf_range(0.7, 1), randf_range(0.7, 1), 1.0)
	
	### White
	#floaty_text.modulate = Color(1.0, 1.0, 1.0, 1.0)
	
	#var amount = randi()%10 - 5
	var amount: Array[String] = ["yippe", "wowowow"] 
	floaty_text.text = amount.pick_random()

	print("it's working!!!!'")
	
	add_child(floaty_text)

func _process(delta: float):
	
	if Input.is_action_just_pressed("game_jump"):
		CreateFloatingText()

	
