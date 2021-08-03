using UnityEngine;

public abstract class PlaneAbility
{
	private int cooldown;
	protected float lastUsed;
	
	public PlaneAbility(int cooldown){
		this.cooldown = cooldown;
	}

	public void setLastUsed(float lastUsed){
		this.lastUsed = lastUsed;
	}

	public float getLastUsed(){
		return this.lastUsed;
	}

	public float getCooldown(){
		if (Time.time - this.lastUsed >= this.cooldown){
			return 0;
		}
		return this.cooldown - (Time.time - this.lastUsed);
	}

	public void TriggerAbilityIfAvailable(){
		if (Time.time - this.lastUsed >= this.cooldown){
			TriggerAbility();
			this.lastUsed = Time.time;
		}
	}

	public abstract void TriggerAbility();
}