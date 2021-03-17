#version 330 core

struct Material{
	float shininess;
	float ambWeight;
	float diffWeight;
	float specWeight;
	sampler2D diffTex0;
	sampler2D diffTex1;
	sampler2D diffTex2;
	sampler2D diffTex3;
	sampler2D diffTex4;
	sampler2D diffTex5;
	sampler2D specTex0;
	sampler2D specTex1;
	sampler2D specTex2;
	sampler2D specTex3;
	sampler2D specTex4;
};
struct ParaLight{
	vec3 lightDir;
	vec3 lightColor;
};
struct PointLight{
	vec3 lightPos;
	vec3 lightColor;
	
	float Kc;
	float Kl;
	float Kq;
};
struct SpotLight{
	vec3 lightPos;
	vec3 lightDir;
	vec3 lightColor;
	float cosInPhi;
	float cosOutPhi;
};
out vec4 fragColor;

in vec3 normal;
in vec3 worldPos;
in vec2 texCoords;

uniform Material material;
uniform SpotLight spotLight;
uniform vec3 camPos;
void main()
{
	vec3 diffTexCol=texture(material.diffTex0, texCoords).rgb+texture(material.diffTex1, texCoords).rgb
				+texture(material.diffTex2, texCoords).rgb+texture(material.diffTex3, texCoords).rgb
				+texture(material.diffTex4, texCoords).rgb+texture(material.diffTex5, texCoords).rgb;
    vec3 amb = diffTexCol*material.ambWeight;
    vec3 diff=vec3(0.0);
	vec3 spec=vec3(0.0);
	
	vec3 n=normalize(normal);
	vec3 lightDir=spotLight.lightDir;
	float cosTheta=dot(lightDir,normalize(worldPos-spotLight.lightPos));
	if(cosTheta>spotLight.cosOutPhi){
		float intensity=smoothstep(spotLight.cosOutPhi,spotLight.cosInPhi,cosTheta); 
		diff = max(dot(n, -lightDir), 0.0)
		*diffTexCol* material.diffWeight * spotLight.lightColor*intensity;
	
		vec3 view=normalize(worldPos-camPos);
		vec3 halfV=-normalize(view+lightDir);
		spec = pow(max(dot(n,halfV), 0.0), material.shininess) 
		* (texture(material.specTex0, texCoords).rgb +texture(material.specTex1, texCoords).rgb
		  +texture(material.specTex2, texCoords).rgb +texture(material.specTex3, texCoords).rgb
		  +texture(material.specTex4, texCoords).rgb)
		* material.specWeight * spotLight.lightColor*intensity;
	
	}
	vec3 result = amb+diff+spec;
    fragColor = vec4(result, 1.0);
	
}