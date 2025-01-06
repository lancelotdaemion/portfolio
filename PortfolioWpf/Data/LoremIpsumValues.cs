namespace PortfolioWpf.LoremIpsum
{
    public class Collection
    {
        public static readonly Dictionary<Guid, string> Values = new Dictionary<Guid, string> {
            { Guid.NewGuid(), "Nam laoreet lectus eu pharetra dignissim." },
            { Guid.NewGuid(), "Suspendisse aliquet metus at lectus sagittis, ut dictum mi convallis." },
            { Guid.NewGuid(), "Ut sed nibh vel metus porttitor pretium nec sollicitudin orci." },
            { Guid.NewGuid(), "Proin cursus purus eget lorem tempus, in auctor metus malesuada." },
            { Guid.NewGuid(), "Phasellus eu elit sed leo mattis lacinia." },
            { Guid.NewGuid(), "Integer placerat dui vel lacus suscipit placerat." },
            { Guid.NewGuid(), "Sed in libero et ligula maximus pulvinar vitae sed neque." },
            { Guid.NewGuid(), "Pellentesque varius lorem nec auctor auctor." }
        };
    }
}