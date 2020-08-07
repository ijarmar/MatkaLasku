<?php 

class CompanyCest
{
    private $companyId;

    // tests
    public function createCompanyViaAPI(\ApiTester $I)
    {
        $I->haveHttpHeader('Content-Type', 'application/json');
        $I->sendPost('/Companies', [
            'name' => 'Sovelluskontti'
        ]);
        $I->seeResponseCodeIs(\Codeception\Util\HttpCode::CREATED);
        $I->seeResponseIsJson();
        $I->seeResponseContainsJson(['name' => 'Sovelluskontti']);
        $this->companyId = json_decode($I->grabResponse(), true)['id'];
    }

    public function getCompanyViaAPI(\ApiTester $I)
    {
        $I->sendGET("/Companies/$this->companyId");
        $I->seeResponseCodeIs(\Codeception\Util\HttpCode::OK);
        $I->seeResponseIsJson();
        $I->seeResponseContainsJson(['name' => 'Sovelluskontti']);
    }

    public function deleteCompanyViaAPI(\ApiTester $I)
    {
        $I->sendDELETE("/Companies/$this->companyId");
        $I->seeResponseCodeIs(\Codeception\Util\HttpCode::OK);
        $I->seeResponseIsJson();
        $I->seeResponseContainsJson(['name' => 'Sovelluskontti']);
    }
}
