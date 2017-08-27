// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Necronaut/Lava Shader"
{
	Properties
	{
		[HideInInspector] __dirty( "", Int ) = 1
		_Albedo("Albedo", 2D) = "white" {}
		_Normal("Normal", 2D) = "bump" {}
		_Mask("Mask", 2D) = "white" {}
		_WoodSpecular("Wood Specular", 2D) = "white" {}
		_TileableFire("TileableFire", 2D) = "white" {}
		_FireIntensity("Fire Intensity", Range( 0 , 2)) = 1.441765
		_FireSpeed("FireSpeed", Range( 0 , 25)) = 25
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf StandardSpecular keepalpha addshadow fullforwardshadows noshadow noambient vertex:vertexDataFunc 
		struct Input
		{
			float2 uv_texcoord;
			float2 texcoord_0;
		};

		uniform sampler2D _Normal;
		uniform float4 _Normal_ST;
		uniform sampler2D _Albedo;
		uniform float4 _Albedo_ST;
		uniform sampler2D _Mask;
		uniform float4 _Mask_ST;
		uniform sampler2D _TileableFire;
		uniform float _FireSpeed;
		uniform float _FireIntensity;
		uniform sampler2D _WoodSpecular;
		uniform float4 _WoodSpecular_ST;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			o.texcoord_0.xy = v.texcoord.xy * float2( 1,1 ) + float2( 0,0 );
		}

		void surf( Input i , inout SurfaceOutputStandardSpecular o )
		{
			float2 uv_Normal = i.uv_texcoord * _Normal_ST.xy + _Normal_ST.zw;
			o.Normal = UnpackNormal( tex2D( _Normal, uv_Normal ) );
			float2 uv_Albedo = i.uv_texcoord * _Albedo_ST.xy + _Albedo_ST.zw;
			o.Albedo = tex2D( _Albedo, uv_Albedo ).xyz;
			float2 uv_Mask = i.uv_texcoord * _Mask_ST.xy + _Mask_ST.zw;
			o.Emission = ( ( tex2D( _Mask, uv_Mask ) * tex2D( _TileableFire, (abs( i.texcoord_0+( _Time.x * _FireSpeed ) * float2(1,1 ))) ) ) * ( _FireIntensity * ( _SinTime.w + 0.0 ) ) ).xyz;
			float2 uv_WoodSpecular = i.uv_texcoord * _WoodSpecular_ST.xy + _WoodSpecular_ST.zw;
			o.Specular = tex2D( _WoodSpecular, uv_WoodSpecular ).xyz;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=12101
2232;92;480;566;6.199594;647.8496;2.2;False;False
Node;AmplifyShaderEditor.TimeNode;9;-589.9,578.599;Float;False;0;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;17;-520.7991,804.6505;Float;False;Property;_FireSpeed;FireSpeed;7;0;25;0;25;0;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;16;-277.5991,626.0505;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.TextureCoordinatesNode;8;-485.3,392.5991;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SinTimeNode;13;119.7003,807.9008;Float;False;0;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.PannerNode;7;-139.5002,481.8991;Float;False;1;1;2;0;FLOAT2;0,0;False;1;FLOAT;0.0;False;1;FLOAT2
Node;AmplifyShaderEditor.SamplerNode;5;173.9002,457.7996;Float;True;Property;_TileableFire;TileableFire;4;0;Assets/AmplifyShaderEditor/Examples/Assets/Textures/Misc/TileableFire.jpg;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;10;222.5002,710.3;Float;False;Property;_FireIntensity;Fire Intensity;5;0;1.441765;0;2;0;1;FLOAT
Node;AmplifyShaderEditor.SamplerNode;3;198.1002,222.3996;Float;True;Property;_Mask;Mask;2;0;Assets/AmplifyShaderEditor/Examples/Assets/Textures/SceneTextures/emiss_2.jpg;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleAddOpNode;12;343.7002,865.5007;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;6;538.9003,334.0003;Float;False;2;2;0;FLOAT4;0.0;False;1;FLOAT4;0.0,0,0,0;False;1;FLOAT4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;11;570.4997,834.9001;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.SamplerNode;2;176.4001,-175.2999;Float;True;Property;_Normal;Normal;1;0;Assets/AmplifyShaderEditor/Examples/Assets/Textures/SceneTextures/WoodNormal.tif;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;FLOAT3;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SamplerNode;1;184.4,-380.4;Float;True;Property;_Albedo;Albedo;0;0;Assets/AmplifyShaderEditor/Examples/Assets/Textures/SceneTextures/WoodDiffuse.tif;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;14;737.4002,203.0991;Float;False;2;2;0;FLOAT4;0.0;False;1;FLOAT;0.0,0,0,0;False;1;FLOAT4
Node;AmplifyShaderEditor.SamplerNode;4;478.5003,10.19949;Float;True;Property;_WoodSpecular;Wood Specular;3;0;Assets/AmplifyShaderEditor/Examples/Assets/Textures/SceneTextures/WoodSpecular.tif;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;15;559.5001,-80.24957;Float;False;Property;_Smoothness;Smoothness;6;0;0;0;2;0;1;FLOAT
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;953.8001,-161.2999;Float;False;True;2;Float;ASEMaterialInspector;0;StandardSpecular;Necronaut/Lava Shader;False;False;False;False;True;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;0;False;0;0;Opaque;0.5;True;True;0;False;Opaque;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;False;0;4;10;25;False;0.5;False;0;Zero;Zero;0;Zero;Zero;Add;Add;0;False;12;0.9191176,0.08785681,0.08785681,0;VertexOffset;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT;0.0;False;5;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;OBJECT;0.0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;16;0;9;1
WireConnection;16;1;17;0
WireConnection;7;0;8;0
WireConnection;7;1;16;0
WireConnection;5;1;7;0
WireConnection;12;0;13;4
WireConnection;6;0;3;0
WireConnection;6;1;5;0
WireConnection;11;0;10;0
WireConnection;11;1;12;0
WireConnection;14;0;6;0
WireConnection;14;1;11;0
WireConnection;0;0;1;0
WireConnection;0;1;2;0
WireConnection;0;2;14;0
WireConnection;0;3;4;0
ASEEND*/
//CHKSM=070C05510D467F5BA35A5818823F0902991AEE20