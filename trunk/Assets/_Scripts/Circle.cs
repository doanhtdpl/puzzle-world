using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour 
{
	public Color[] colors;
	public float[] radius;

	public float circleDelay = 1.0f;
	public float growSpeed = 0.34f;
	public AnimationCurve curve;
	public Material material;

	float startTime;

	void Start()
	{
		radius = new float[colors.Length];
		for(int i=0; i<radius.Length; ++i)
		{
			radius[i] = 0.0f;
		}

		startTime = Time.time;
	}
	
	void Update()
	{
		float currentTime = Time.time - startTime;

		if(currentTime > 5.0f)
		{
			currentTime = 0.0f;
			startTime = Time.time;
			for(int i=0; i<radius.Length; ++i)
			{
				radius[i] = 0.0f;
			}
		}
		
		for(int i=0; i<colors.Length; ++i)
		{
			if(currentTime > circleDelay * i && radius[i] < 1.0f)
			{
				radius[i] += growSpeed * Time.deltaTime;
				radius[i] = Mathf.Min(1.0f, radius[i]);
			}
		}

		int iIndex = 1;
		for(int i=0; i<colors.Length; ++i)
		{
			if(radius[i] < 1.0f && i > 0)
			{
				iIndex++;
			}
			material.SetFloat("_Radius" + iIndex, curve.Evaluate(radius[i]));
			material.SetVector("_Color" + iIndex, colors[i]);
		}
	}

	public void SetData(Color[] _colors, float[] _radius)
	{
		for(int i=0; i<_colors.Length; ++i)
		{
			renderer.material.SetFloat("_Radius" + (i+1), curve.Evaluate(_radius[i]));
			renderer.material.SetVector("_Color" + (i+1), _colors[i]);
		}
	}
}
