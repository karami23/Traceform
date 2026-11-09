using Traceform.Application.FAQs.DTOs;
using Traceform.Application.FAQs.Interfaces;

namespace Traceform.Application.FAQs.Queries.GetFAQs;

public class GetFAQsHandler
{
    private readonly IFAQRepository _faqRepository;

    public GetFAQsHandler(
        IFAQRepository faqRepository)
    {
        _faqRepository = faqRepository;
    }

    public async Task<IReadOnlyList<FAQDto>> HandleAsync(
        GetFAQsQuery query,
        CancellationToken cancellationToken = default)
    {
        var faqs = await _faqRepository.GetPublishedAsync(
            cancellationToken);

        return faqs
            .Select(faq => new FAQDto(
                faq.Id,
                faq.Question,
                faq.Answer,
                faq.DisplayOrder))
            .ToList();
    }
}