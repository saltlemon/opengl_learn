#version 330 core
struct Material{
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


out vec4 FragColor;
in vec3 normal;
in vec3 position;
in vec2 texCoords;

uniform Material material;
uniform vec3 cameraPos;
uniform samplerCube skybox;
void main()
{
	vec3 diffTexCol=texture(material.diffTex0, texCoords).rgb+texture(material.diffTex1, texCoords).rgb
				+texture(material.diffTex2, texCoords).rgb+texture(material.diffTex3, texCoords).rgb
				+texture(material.diffTex4, texCoords).rgb+texture(material.diffTex5, texCoords).rgb;
    vec3 amb = diffTexCol*material.ambWeight;
	
	vec3 diff=diffTexCol*material.diffWeight;
	
	vec3 I = normalize(position - cameraPos);
	vec3 R = reflect(I, normalize(normal));
    vec3 spec = texture(skybox, R).rgb* (texture(material.specTex0, texCoords).rgb +texture(material.specTex1, texCoords).rgb
		  +texture(material.specTex2, texCoords).rgb +texture(material.specTex3, texCoords).rgb
		  +texture(material.specTex4, texCoords).rgb)* material.specWeight ;
	vec3 result = amb+diff+spec;
    FragColor = vec4(result, 1.0);
}