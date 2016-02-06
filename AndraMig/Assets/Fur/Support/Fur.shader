//Updated for d3d11 by Ali Afroughe

Shader "Fur"
{
	Properties
	{
		_FurLength ("Fur Length", Range (.0002, 1)) = .25
		_MainTex ("Base (RGB)", 2D) = "white" { }
		//_Cutoff ("Alpha Cutoff", Range (0, 1)) = .0001
		_EdgeFade ("Edge Fade", Range(0,1)) = 0.4
		_LightDirection0 ("Light Direction 0, Ambient", Vector) = (1,0,0,1)
		_MyLightColor0 ("Light Color 0", Color) = (1,1,1,1)
		_LightDirection1 ("Light Direction 1, Ambient", Vector) = (1,0,0,1)
		_MyLightColor1 ("Light Color 1", Color) = (1,1,1,1)
	}
	Category
	{
		ZWrite Off
		Tags {"Queue" = "Transparent"}
		Blend SrcAlpha OneMinusSrcAlpha
	//	Alphatest Greater [_Cutoff]
		SubShader
		{
			Pass
			{
				ZWrite On
				
				CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
				#pragma vertex VertexProgram
				#pragma fragment FragmentProgram
				#include "FurHelpers.cginc"

				v2f VertexProgram (appdata_base v)
				{
					v2f o;
					FurVertexPass(0, v, _FurLength, o.pos, o.fog, o.color, o.uv);	
					return o;
				}
				
				
				float4 FragmentProgram(v2f input):COLOR
				{
					return input.color * float4(tex2D(_MainTex,input.uv.xy).rgb,1);
				}
				
				ENDCG
			}
			Pass
			{
				CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
				#pragma vertex VertexProgram
				#include "FurHelpers.cginc"
				#pragma fragment FragmentProgram

				v2f VertexProgram (appdata_base v)
				{
					v2f o;
					FurVertexPass(0.05, v, _FurLength, o.pos, o.fog, o.color, o.uv);	
					return o;
				}
				
				float4 FragmentProgram(v2f input):COLOR
				{
					return input.color * tex2D(_MainTex,input.uv.xy);
				}
				ENDCG
			}
			Pass
			{
				CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
				#pragma vertex VertexProgram
				#include "FurHelpers.cginc"
				#pragma fragment FragmentProgram

				v2f VertexProgram (appdata_base v)
				{
					v2f o;
					FurVertexPass(0.1, v, _FurLength, o.pos, o.fog, o.color, o.uv);	
					return o;
				}
				
				float4 FragmentProgram(v2f input):COLOR
				{
					return input.color * tex2D(_MainTex,input.uv.xy);
				}
				
				ENDCG

			}
			Pass
			{
				CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
				#pragma vertex VertexProgram
				#include "FurHelpers.cginc"
				#pragma fragment FragmentProgram

				v2f VertexProgram (appdata_base v)
				{
					v2f o;
					FurVertexPass(0.15, v, _FurLength, o.pos, o.fog, o.color, o.uv);	
					return o;
				}
				float4 FragmentProgram(v2f input):COLOR
				{
					return input.color * tex2D(_MainTex,input.uv.xy);
				}
				ENDCG
			}
			Pass
			{
				CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
				#pragma vertex VertexProgram
				#include "FurHelpers.cginc"
				#pragma fragment FragmentProgram

				v2f VertexProgram (appdata_base v)
				{
					v2f o;
					FurVertexPass(0.2, v, _FurLength, o.pos, o.fog, o.color, o.uv);	
					return o;
				}
				float4 FragmentProgram(v2f input):COLOR
				{
					return input.color * tex2D(_MainTex,input.uv.xy);
				}
				ENDCG
			}
			Pass
			{
				CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
				#pragma vertex VertexProgram
				#include "FurHelpers.cginc"
				#pragma fragment FragmentProgram

				v2f VertexProgram (appdata_base v)
				{
					v2f o;
					FurVertexPass(0.25, v, _FurLength, o.pos, o.fog, o.color, o.uv);	
					return o;
				}
				float4 FragmentProgram(v2f input):COLOR
				{
					return input.color * tex2D(_MainTex,input.uv.xy);
				}
				ENDCG
			}
			Pass
			{
				CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
				#pragma vertex VertexProgram
				#include "FurHelpers.cginc"
				#pragma fragment FragmentProgram

				v2f VertexProgram (appdata_base v)
				{
					v2f o;
					FurVertexPass(0.3, v, _FurLength, o.pos, o.fog, o.color, o.uv);	
					return o;
				}
				float4 FragmentProgram(v2f input):COLOR
				{
					return input.color * tex2D(_MainTex,input.uv.xy);
				}
				ENDCG
			}
			Pass
			{
				CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
				#pragma vertex VertexProgram
				#include "FurHelpers.cginc"
				#pragma fragment FragmentProgram

				v2f VertexProgram (appdata_base v)
				{
					v2f o;
					FurVertexPass(0.35, v, _FurLength, o.pos, o.fog, o.color, o.uv);	
					return o;
				}
				float4 FragmentProgram(v2f input):COLOR
				{
					return input.color * tex2D(_MainTex,input.uv.xy);
				}
				ENDCG
			}
			Pass
			{
				CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
				#pragma vertex VertexProgram
				#include "FurHelpers.cginc"
				#pragma fragment FragmentProgram

				v2f VertexProgram (appdata_base v)
				{
					v2f o;
					FurVertexPass(0.4, v, _FurLength, o.pos, o.fog, o.color, o.uv);	
					return o;
				}
				float4 FragmentProgram(v2f input):COLOR
				{
					return input.color * tex2D(_MainTex,input.uv.xy);
				}
				ENDCG
			}
			Pass
			{
				CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
				#pragma vertex VertexProgram
				#include "FurHelpers.cginc"
				#pragma fragment FragmentProgram

				v2f VertexProgram (appdata_base v)
				{
					v2f o;
					FurVertexPass(0.45, v, _FurLength, o.pos, o.fog, o.color, o.uv);	
					return o;
				}
				float4 FragmentProgram(v2f input):COLOR
				{
					return input.color * tex2D(_MainTex,input.uv.xy);
				}
				ENDCG

			}
			Pass
			{
				CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
				#pragma vertex VertexProgram
				#include "FurHelpers.cginc"
				#pragma fragment FragmentProgram

				v2f VertexProgram (appdata_base v)
				{
					v2f o;
					FurVertexPass(0.5, v, _FurLength, o.pos, o.fog, o.color, o.uv);	
					return o;
				}
				float4 FragmentProgram(v2f input):COLOR
				{
					return input.color * tex2D(_MainTex,input.uv.xy);
				}
				ENDCG
			}
			Pass
			{
				CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
				#pragma vertex VertexProgram
				#include "FurHelpers.cginc"
				#pragma fragment FragmentProgram

				v2f VertexProgram (appdata_base v)
				{
					v2f o;
					FurVertexPass(0.55, v, _FurLength, o.pos, o.fog, o.color, o.uv);	
					return o;
				}
				float4 FragmentProgram(v2f input):COLOR
				{
					return input.color * tex2D(_MainTex,input.uv.xy);
				}
				ENDCG
			}
			Pass
			{
				CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
				#pragma vertex VertexProgram
				#include "FurHelpers.cginc"
				#pragma fragment FragmentProgram

				v2f VertexProgram (appdata_base v)
				{
					v2f o;
					FurVertexPass(0.60, v, _FurLength, o.pos, o.fog, o.color, o.uv);	
					return o;
				}
				float4 FragmentProgram(v2f input):COLOR
				{
					return input.color * tex2D(_MainTex,input.uv.xy);
				}
				ENDCG 
			}
			Pass
			{
				CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
				#pragma vertex VertexProgram
				#include "FurHelpers.cginc"
				#pragma fragment FragmentProgram

				v2f VertexProgram (appdata_base v)
				{
					v2f o;
					FurVertexPass(0.65, v, _FurLength, o.pos, o.fog, o.color, o.uv);	
					return o;
				}
				float4 FragmentProgram(v2f input):COLOR
				{
					return input.color * tex2D(_MainTex,input.uv.xy);
				}
				ENDCG
			}
			Pass
			{
				CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
				#pragma vertex VertexProgram
				#include "FurHelpers.cginc"
				#pragma fragment FragmentProgram

				v2f VertexProgram (appdata_base v)
				{
					v2f o;
					FurVertexPass(0.70, v, _FurLength, o.pos, o.fog, o.color, o.uv);	
					return o;
				}
				float4 FragmentProgram(v2f input):COLOR
				{
					return input.color * tex2D(_MainTex,input.uv.xy);
				}
				ENDCG
			}
			Pass
			{
				CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
				#pragma vertex VertexProgram
				#include "FurHelpers.cginc"
				#pragma fragment FragmentProgram

				v2f VertexProgram (appdata_base v)
				{
					v2f o;
					FurVertexPass(0.75, v, _FurLength, o.pos, o.fog, o.color, o.uv);	
					return o;
				}
				float4 FragmentProgram(v2f input):COLOR
				{
					return input.color * tex2D(_MainTex,input.uv.xy);
				}
				ENDCG
			}
			Pass
			{
				CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
				#pragma vertex VertexProgram
				#include "FurHelpers.cginc"
				#pragma fragment FragmentProgram

				v2f VertexProgram (appdata_base v)
				{
					v2f o;
					FurVertexPass(0.8, v, _FurLength, o.pos, o.fog, o.color, o.uv);	
					return o;
				}
				float4 FragmentProgram(v2f input):COLOR
				{
					return input.color * tex2D(_MainTex,input.uv.xy);
				}
				ENDCG
			}
			Pass
			{
				CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
				#pragma vertex VertexProgram
				#include "FurHelpers.cginc"
				#pragma fragment FragmentProgram

				v2f VertexProgram (appdata_base v)
				{
					v2f o;
					FurVertexPass(0.85, v, _FurLength, o.pos, o.fog, o.color, o.uv);	
					return o;
				}
				float4 FragmentProgram(v2f input):COLOR
				{
					return input.color * tex2D(_MainTex,input.uv.xy);
				}
				ENDCG
			}
			Pass
			{
				CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
				#pragma vertex VertexProgram
				#include "FurHelpers.cginc"
				#pragma fragment FragmentProgram

				v2f VertexProgram (appdata_base v)
				{
					v2f o;
					FurVertexPass(0.9, v, _FurLength, o.pos, o.fog, o.color, o.uv);	
					return o;
				}
				float4 FragmentProgram(v2f input):COLOR
				{
					return input.color * tex2D(_MainTex,input.uv.xy);
				}
				ENDCG
			}
			Pass
			{
				CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it does not contain a surface program or both vertex and fragment programs.
#pragma exclude_renderers gles
				#pragma vertex VertexProgram
				#include "FurHelpers.cginc"
				#pragma fragment FragmentProgram

				v2f VertexProgram (appdata_base v)
				{
					v2f o;
					FurVertexPass(0.95, v, _FurLength, o.pos, o.fog, o.color, o.uv);	
					return o;
				}
				float4 FragmentProgram(v2f input):COLOR
				{
					return input.color * tex2D(_MainTex,input.uv.xy);
				}
				ENDCG
			}
		}
		Fallback " VertexLit", 1
	}
}
