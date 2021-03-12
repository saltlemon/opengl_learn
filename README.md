# opengl学习日记
## 光照贴图  -3.12
 简单的说就是将我们原本设置的物体的纯颜色换为纹理贴图。
 ```
  vec3 diff = max(dot(n, -lightDir), 0.0)* texture(material.diffTex, texCoords).rgb 
  * material.diffWeight ;
  vec3 spec = pow(max(dot(n,halfV), 0.0), material.shininess) * 
  texture(material.specTex, texCoords).rgb*material.specWeight;
 ```
 坑：在使用图片读取函数stbi_load()的时候，读取png文件出错，将文件转化为jpg文件才读取成功。
 ![光照贴图](https://github.com/saltlemon/opengl_learn/blob/%E5%85%89%E7%85%A7/result_img/%E5%85%89%E7%85%A7%E8%B4%B4%E5%9B%BE.png )

