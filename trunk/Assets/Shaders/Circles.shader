Shader "Custom/Circles" 
{
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
    	_Radius1 ("Radius1", Range(0.0, 1.0)) = 1.0
    	_Color1 ("Color1", Color) = (1.0, 0.0, 0.0, 1.0)
    	_Radius2 ("Radius2", Range(0.0, 1.0)) = 0.75
    	_Color2 ("Color2", Color) = (0.0, 1.0, 0.0, 1.0)
    	_Radius3 ("Radius3", Range(0.0, 1.0)) = 0.5
    	_Color3 ("Color3", Color) = (1.0, 1.0, 0.0, 1.0)
    	_Radius4 ("Radius4", Range(0.0, 1.0)) = 0.25
    	_Color4 ("Color4", Color) = (1.0, 0.0, 1.0, 1.0)
	}
	
	SubShader 
	{
		LOD 200
		
		Tags
        {
            "Queue" = "Transparent"
            "IgnoreProjector" = "True"
            "RenderType" = "Transparent"
        }
        
        Pass {
        	Cull Off
            Lighting Off
            ZWrite Off
            Offset -1, -1
            Fog { Mode Off }
            ColorMask RGB
        	Blend SrcAlpha OneMinusSrcAlpha
        	
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            
            uniform sampler2D _MainTex;
			uniform float _Radius1;
			uniform float4 _Color1;
			uniform float _Radius2;
			uniform float4 _Color2;
			uniform float _Radius3;
			uniform float4 _Color3;
			uniform float _Radius4;
			uniform float4 _Color4;

			struct vertexInput {
	            float4 vertex : POSITION;
	            float4 texcoord : TEXCOORD0;
	         };
	         struct vertexOutput {
	            float4 pos : SV_POSITION;
	            float4 tex : TEXCOORD0;
	         };
	 
	         vertexOutput vert(vertexInput input) 
	         {
	            vertexOutput output;
	 
	            output.tex = input.texcoord;
	            output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
	            return output;
	         }
	 
	         float4 frag(vertexOutput input) : COLOR
	         {
				float2 radius = input.tex.xy - 0.5;
				
				if(length(radius) < (_Radius4/2))
				{
					return _Color4;
				}
				else if(length(radius) < (_Radius3/2))
				{
					return _Color3;
				}
				else if(length(radius) < (_Radius2/2))
				{
					return _Color2;
				}
				else if(length(radius) < (_Radius1/2))
				{
					return _Color1;
				}
				else
				{
	            	return half4(0,0,0,0);
				}
	         }

            ENDCG
        }
    }
}
