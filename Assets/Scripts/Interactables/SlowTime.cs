<<<<<<< HEAD
﻿


using System.Collections;
=======
﻿using System.Collections;
>>>>>>> 036d8778ef64ca5365ce6f6e65adb44f6eef442e
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class SlowTime : ShotInteractable {


<<<<<<< HEAD
	[SerializeField] Transform player;
    public float time;
=======
	[SerializeField] float time;
	
	[SerializeField] Transform player;

>>>>>>> 036d8778ef64ca5365ce6f6e65adb44f6eef442e
	Hand[] hands;

	public override void Interact(){
		base.Interact();
		Time.timeScale = time;
		
		
	}

	
}
