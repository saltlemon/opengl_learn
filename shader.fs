#version 330 core
<<<<<<< Updated upstream
=======

struct Material{
	float shininess;
	float ambWeight;
	float diffWeight;
	float specWeight;
	sampler2D diffTex0;
	sampler2D diffTex1;
	sampler2D diffTex2;
	sampler2D specTex0;
	sampler2D specTex1;
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
>>>>>>> Stashed changes
out vec4 fragColor;

in vec3 normal;
in vec3 worldPos;
uniform vec3 objectColor;
uniform vec3 lightColor;
uniform vec3 lightPos;
uniform vec3 camPos;
void main()
{
<<<<<<< Updated upstream
    float amb = 0.1;
    

	vec3 n=normalize(normal);
	vec3 lightDir = normalize(worldPos-lightPos);
	float diff = max(dot(n, -lightDir), 0.0);
	
	vec3 view=normalize(worldPos-camPos);
	vec3 halfV=-normalize(view+lightDir);
	float spec = pow(max(dot(n,halfV), 0.0), 32);
=======
    vec3 amb = (texture(material.diffTex0, texCoords).rgb+texture(material.diffTex1, texCoords).rgb
				+texture(material.diffTex2, texCoords).rgb)*material.ambWeight;
    vec3 diff=vec3(0.0);
	vec3 spec=vec3(0.0);
	
	vec3 n=normalize(normal);
	vec3 lightDir=spotLight.lightDir;
	float cosTheta=dot(lightDir,normalize(worldPos-spotLight.lightPos));
	if(cosTheta>spotLight.cosOutPhi){
		float intensity=smoothstep(spotLight.cosOutPhi,spotLight.cosInPhi,cosTheta); 
		diff = max(dot(n, -lightDir), 0.0)
		*( texture(material.diffTex0, texCoords).rgb+texture(material.diffTex1, texCoords).rgb
		+texture(material.diffTex2, texCoords).rgb)* material.diffWeight * spotLight.lightColor*intensity;
	
		vec3 view=normalize(worldPos-camPos);
		vec3 halfV=-normalize(view+lightDir);
		spec = pow(max(dot(n,halfV), 0.0), material.shininess) 
		* (texture(material.specTex0, texCoords).rgb +texture(material.specTex1, texCoords).rgb)
		* material.specWeight * spotLight.lightColor*intensity;
>>>>>>> Stashed changes
	
	vec3 result = (amb+diff+spec*0.5)*lightColor* objectColor;
    fragColor = vec4(result, 1.0);
	
}