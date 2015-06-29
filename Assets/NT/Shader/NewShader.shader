Shader "Custom/NewShader" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_BumpMap("Bumpmap",2d)="bump"{}
	}
	SubShader {
		Tags { "RenderType"="Opaque" } //标签
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		
		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap;
		};

		sampler2D _MainTex;
		sampler2D _BumpMap;
		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);//计算反射光颜色
			o.Albedo = c.rgb;
			o.Alpha = c.a;
			o.Normal=UnpackNormal(tex2D (_BumpMap, IN.uv_MainTex));//计算法线
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
