#version 330 core
<<<<<<< Updated upstream
out vec4 FragColor;

void main()
{
    FragColor = vec4(1.0);
=======

struct Material{
	sampler2D diffTex0;
};
out vec4 fragColor;


in vec2 texCoords;

uniform Material material;
void main()
{
	
		 
    fragColor = vec4(texture(material.diffTex0, texCoords).rgb, 1.0);
	
>>>>>>> Stashed changes
}