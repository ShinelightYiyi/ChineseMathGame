Shader "Unlit/Blend"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_BlendTex ("Texture", 2D) = "white" {}
	}
	CGINCLUDE
	#include "UnityCG.cginc"
	struct appdata
	{
		float4 vertex : POSITION;
		float2 uv : TEXCOORD0;
	};
	struct v2f
	{
		float2 uv : TEXCOORD0;
		UNITY_FOG_COORDS(1)
		float4 vertex : SV_POSITION;
	};
	sampler2D _MainTex;
	float4 _MainTex_ST;
	sampler2D _BlendTex;
	v2f vert (appdata v)
	{
		v2f o;
		o.vertex = UnityObjectToClipPos(v.vertex);
		o.uv = TRANSFORM_TEX(v.uv, _MainTex);
		UNITY_TRANSFER_FOG(o,o.vertex);
		return o;
	}
	fixed4 frag (v2f i) : SV_Target
	{
		
		fixed4 A = tex2D(_MainTex, i.uv);	//AΪ��ͼrgba ��ά����
		fixed4 B = tex2D(_BlendTex,i.uv);	//BΪ���ͼrgba ��ά����
		
		//--------ֻ������Ĵ���------------
		fixed4 C=A+2*B-1;
		//---------------------------------

		// fixed4 C =A*(1-B.a)+B*(B.a);	//����͸���Ȼ��

		// fixed4 C =min(A,B);	//�䰵

		// fixed4 C =max(A,B);	//����

		// fixed4 C =A*B ;	//��Ƭ����


		// fixed4 C=1-((1-A)*(1-B));//��ɫ A+B-A*B

		// fixed4 C =A-((1-A)*(1-B))/B; //��ɫ����

		// fixed4 C= A+(A*B)/(1-B); //��ɫ����

		// fixed4 C=A+B-1;//���Լ���

		// fixed4 C=A+B; //���Լ���
		
		// fixed4 ifFlag= step(A,fixed4(0.5,0.5,0.5,0.5));
		// fixed4 C=ifFlag*A*B*2+(1-ifFlag)*(1-(1-A)*(1-B)*2);//����
		
		// fixed4 ifFlag= step(B,fixed4(0.5,0.5,0.5,0.5));
		// fixed4 C=ifFlag*A*B*2+(1-ifFlag)*(1-(1-A)*(1-B)*2); //ǿ��

		// fixed4 ifFlag= step(B,fixed4(0.5,0.5,0.5,0.5));
		// fixed4 C=ifFlag*(A*B*2+A*A*(1-B*2))+(1-ifFlag)*(A*(1-B)*2+sqrt(A)*(2*B-1)); //���
		
		// fixed4 ifFlag= step(B,fixed4(0.5,0.5,0.5,0.5));
		// fixed4 C=ifFlag*(A-(1-A)*(1-2*B)/(2*B))+(1-ifFlag)*(A+A*(2*B-1)/(2*(1-B))); //����

		// fixed4 ifFlag= step(B,fixed4(0.5,0.5,0.5,0.5));	//��֪��Ϊʲô�ܶ���������Ч����д����min ʵ��Ч����ԭӦ������һ��minһ��max
		// fixed4 C=ifFlag*(min(A,2*B))+(1-ifFlag)*(max(A,( B*2-1))); //���  
		
		// fixed4 C=A+2*B-1; //���Թ�

		// fixed4 ifFlag= step(A+B,fixed4(1,1,1,1));
		// fixed4 C=ifFlag*(fixed4(0,0,0,0))+(1-ifFlag)*(fixed4(1,1,1,1)); //ʵɫ���

		// fixed4 C=A+B-A*B*2; //�ų�

		// fixed4 C=abs(A-B); //��ֵ

		// fixed4 ifFlag= step(B.r+B.g+B.b,A.r+A.g+A.b);
		// fixed4 C=ifFlag*(B)+(1-ifFlag)*(A); //��ɫ

		// fixed4 ifFlag= step(B.r+B.g+B.b,A.r+A.g+A.b);
		// fixed4 C=ifFlag*(A)+(1-ifFlag)*(B); //ǳɫ

		// fixed4 C=A-B; //��ȥ

		// fixed4 C=A/B; //����

		return C;
	}
	
	ENDCG
	SubShader
	{
		Tags { "Queue"="Transparent" }
		
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			ENDCG
		}
	}
	}