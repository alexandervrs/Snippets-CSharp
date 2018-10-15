
/**
 * HLSL.cs
 * HLSL shader related snippets for C#
 */

/* uniforms */
uniform sampler2D SourceTexture_1;


/* -----------------------------------------
   Conversions
----------------------------------------- */

// Source to RBGA
float4 SourceRGBA_1 = tex2D(SourceTexture_1, i.texcoord);

// RGBA to UV
float2 RGBA2UV_1 = float2(SourceRGBA_1.r, SourceRGBA_1.g);

// UV to RGBA
float4 UV2RGBA_1 = float4(RGBA2UV_1.r, RGBA2UV_1.g, 0, 1);


/* -----------------------------------------
   Blend Textures
----------------------------------------- */

// Blend 2 Textures
float4 Blend2RGBA(float4 origin, float4 overlay, float blend)
{
    float4 o = origin; 
    o.a = overlay.a + origin.a * (1 - overlay.a);
    o.rgb = (overlay.rgb * overlay.a + origin.rgb * origin.a * (1 - overlay.a)) * (o.a+0.0000001);
    o.a = saturate(o.a);
    o = lerp(origin, o, blend);
    return o;
}

float  fadeAmount = 1.0f;
float4 SourceRGBA_1 = Blend2RGBA(SourceRGBA_1, SourceRGBA_2, fadeAmount); 

// Blend Subtract A with B
float  fadeAmount = 1.0f;
SourceRGBA_1 = lerp(SourceRGBA_1, SourceRGBA_1 - SourceRGBA_2, fadeAmount);

// Blend Additive
float  fadeAmount = 1.0f;
SourceRGBA_1 = lerp(SourceRGBA_1, SourceRGBA_1*SourceRGBA_1.a + SourceRGBA_2*SourceRGBA_2.a, fadeAmount * SourceRGBA_2.a);

// Blend Multiply
float  fadeAmount = 1.0f;
SourceRGBA_1 = lerp(SourceRGBA_1, SourceRGBA_1 * SourceRGBA_2, fadeAmount);

// Blend Division
float  fadeAmount = 1.0f;
SourceRGBA_1 = lerp(SourceRGBA_1, SourceRGBA_1 / SourceRGBA_2, fadeAmount);


/* -----------------------------------------
   UV Operations
----------------------------------------- */

// flip UVs
float2 UVFlipH(float2 uv)
{
    uv.x = 1 - uv.x;
    return uv;
}

float2 UVFlipV(float2 uv)
{
    uv.y = 1 - uv.y;
    return uv;
}


/* -----------------------------------------
   Final Output
----------------------------------------- */

// Output final RGBA
float4 FinalResult = SourceRGBA_1;
FinalResult.rgb    *= i.color.rgb;
FinalResult.a      = FinalResult.a * i.color.a;
FinalResult.rgb    *= FinalResult.a;
FinalResult.a      = saturate(FinalResult.a);
return FinalResult;


/* 

	Converting from GLSL to HLSL

	vec2, vec3, vec4 --> float2, float3, float4 
	
	texture2D() --> tex2d()
	mix() --> lerp()
	atan(uv.y, uv.x) --> atan2(uv.x, uv.y)
	
	gl_Fragcoord --> return float4(c.rgb, c.a);

*/

